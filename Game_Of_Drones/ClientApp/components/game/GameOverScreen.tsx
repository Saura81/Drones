import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';

export class GameOverScreen extends React.Component<RouteComponentProps<{}>> {
    constructor(props) {
        super(props);

        let winner = this.props.match.params["winner"];

        if (winner !== null) {
            fetch('api/ScoreController/SetNewScore/' + winner, {
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                }
            })  .then(response => response.json() as Promise<string>)
                .then(data => {
                    console.log(data);
                });
        }
        
        this.handleStart = this.handleStart.bind(this);
    }

    public render() {

        return <div>
            <h1>We Have a WINNER!!</h1>
            <hr />
            <div>
                <h3>{this.props.match.params["winner"]} is the new EMPEROR!!</h3>
                <button className="btn" onClick={this.handleStart}>Play Again</button>
            </div >
        </div>;
    }

    private handleStart(e) {
        e.preventDefault();
        this.props.history.push("/playerscreen");
    }
}