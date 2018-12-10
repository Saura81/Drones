import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface FetchScoreDataState {
    score: Score[];
    loading: boolean;
}

export class FetchScoreData extends React.Component<RouteComponentProps<{}>, FetchScoreDataState> {
    constructor() {
        super();
        this.state = { score: [], loading: true };

        fetch('api/Score/GetScores')
            .then(response => response.json() as Promise<Score[]>)
            .then(data => {
                this.setState({ score: data, loading: false });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchScoreData.renderScoreTable(this.state.score);

        return <div>
            <h1>High Scores</h1>
            <p>Amount of games won per player.</p>
            { contents }
        </div>;
    }

    private static renderScoreTable(scores: Score[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Player Name</th>
                    <th>Games Won</th>                   
                </tr>
            </thead>
            <tbody>
                {scores.map(score =>
                    <tr key={score.scoreId}>
                        <td>{score.playerName}</td>
                        <td>{score.gamesWon}</td>
                    </tr>
            )}
            </tbody>
        </table>;
    }
}

interface Score {
    scoreId: string;
    playerName: string;
    gamesWon: number;
}
