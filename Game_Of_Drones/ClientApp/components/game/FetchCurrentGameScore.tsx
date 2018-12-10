import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface FetchRoundScoreData {
    score: Score[];
    loading: boolean;
}

export default class FetchCurrentGameScore extends React.Component<RouteComponentProps<{}>, FetchRoundScoreData> {
    constructor() {
        super();
        this.state = { score: [], loading: true };

        fetch('api/GameController/GetGameScores')
            .then(response => response.json() as Promise<Score[]>)
            .then(data => {
                this.setState({ score: data, loading: false });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchCurrentGameScore.renderScoreTable(this.state.score);

        return <div>
            <h3>Round Scores</h3>
            {contents}
        </div>;
    }

    private static renderScoreTable(scores: Score[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Round</th>
                    <th>Winner</th>
                </tr>
            </thead>
            <tbody>
                {scores.map(score =>
                    <tr key={score.round}>
                        <td>{score.round}</td>
                        <td>{score.winner}</td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}

interface Score {
    round: string;
    winner: string;
}
