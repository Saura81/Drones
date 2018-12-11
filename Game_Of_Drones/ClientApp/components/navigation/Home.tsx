import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Home extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <div>
                <img src={require('././images/header.png')} style={{ flex: 1, height: undefined, width: '100%' }} />
            </div>
            <h1>Game of drones rules!</h1>
            <p>In the <b> Game of Drones </b> there are two players trying to conquer each other. </p>

            <p> Players take turns to make their move, choosing Paper, Rock or Scissors. Each move beats another, just like the usual game.<em>(No lizard beats spock this time, sorry!!)</em>.</p>
             <h4>In case you didn't know!!</h4>
            <ul>
                <li>Paper beats Rock.</li>
                <li>Rock beats scissors.</li>
                <li>Scissors beat Paper</li>
            </ul>
            <h4>Going further</h4>
            <p>
                The first player to beat the other player 3 times wins the battle.
            </p>
        </div>;
    }
}
