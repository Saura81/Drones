import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';

interface RoundDataState {
    title: string;
    loading: boolean;
    moveSet: Array<any>;
    playerMove: string;
    playerName: string;
    score: Score[];
}

export class Round extends React.Component<RouteComponentProps<{}>, RoundDataState> {
       constructor(props) {
        super(props);

        this.state = { title: "", loading: true, moveSet: [], playerMove: "", playerName:"" , score:[]};


        fetch('api/GameController/GetMoveSet')
            .then(response => response.json() as Promise<Array<any>>)
            .then(data => {
                this.setState({ moveSet: data });
            });

        let id = this.props.match.params["roundId"];

        if (id > 0) {
            fetch('api/GameController/GetCurrentRound/' + id, {
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                }
            })
                .then(response => response.json() as Promise<string>)
                .then(data => {
                    this.setState({ title: "Round #" + this.props.match.params["roundId"], loading: false, playerName: data});
                });
        }

        this.handleSave = this.handleSave.bind(this);
    }

    public render() {

        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderCreateForm(this.state.moveSet);

        this.loadScores();

        let scores =
            (
                <div>
                    <h3>Current game Scores</h3>
                    < table className='table' >
                        <thead>
                            <tr>
                                <th>Round</th>
                                <th>Winner</th>
                            </tr>
                        </thead>
                        <tbody>
                            {this.state.score.map(score =>
                                <tr key={score.round}>
                                    <td>{score.round}</td>
                                    <td>{score.winner}</td>
                                </tr>
                            )}
                        </tbody>
                    </table>
                </div>
            );

        return <div>
            <h1>{this.state.title}</h1>
            <h3>Player {this.state.playerName} turn</h3>
            <hr />
            {contents}
            {scores}

        </div>;
    }

    loadScores() {
        fetch('api/GameController/GetGameScores')
            .then(response => response.json() as Promise<Score[]>)
            .then(data => {
                this.setState({ score: data });
            });  
    }

    // This will handle the submit form event.
    private handleSave(event) {
        event.preventDefault();        

        const data = new FormData(event.target);

        fetch('api/GameController/EditRound', {
            method: 'PUT',
            body: data,
        }).then((response) => response.json() as Promise<Array<string>>)
            .then((array) => {
                if (array.length > 1) {
                    this.setState({ playerName: array[1] });
                    this.setState({ title: "Round #" + array[0]});
                    this.props.history.push("/round/" + array[0]);
                }
                else {
                    this.props.history.push("/gameoverscreen/" + array[0]) 
                }
            }) 
    }
    private renderCreateForm(moveSet: Array<any>) {
        
        return (
            <form onSubmit={this.handleSave} >
                 <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="Move">Move</label>
                    <div className="col-md-4">
                        <select className="form-control" data-val="true" name="move" defaultValue={this.state.playerMove} required>
                            <option value="">-- Select Move --</option>
                            {moveSet.map(move =>
                                <option key={move.moveId} value={move.moveName}>{move.moveName}</option>
                            )}
                        </select>
                    </div>
                </div >
                <div className="form-group">
                    <button type="submit" className="btn btn-default">Save</button>
                </div >
            </form >

        )
    }

}

interface Score {
    round: string;
    winner: string;
}

