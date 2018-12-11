import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';

interface AddPlayerDataState {
    title: string;
    playerData: PlayerData;
}

export class PlayerScreen extends React.Component<RouteComponentProps<{}>, AddPlayerDataState> {
    constructor(props) {
        super(props);

        //Creating a new player selection screen
        this.state = { title: "Add players to the new Game of Drones", playerData: new PlayerData };

        // This binding is necessary to make "this" work in the callback
        this.handleSave = this.handleSave.bind(this);
        this.handleCancel = this.handleCancel.bind(this);
    }

    public render() {
        let contents =  this.renderCreateForm();

        return <div className="col-md-16 col-md-offset-2">
            <div>
                <img src={require('../navigation/images/top.png')} style={{ flex: 1, height: undefined, width: undefined }} />
            </div>
            <h1>{this.state.title}</h1>
            <hr />
            {contents}
        </div>;
    }

    // This will handle the submit form event.
    private handleSave(event) {
        event.preventDefault();
        const data = new FormData(event.target);

        // POST request for Add new Players.
        fetch('api/GameController/CreateGame', {
                method: 'POST',
            body: data,
        }).then((response) => response.json() as Promise<number>)
                .then((roundId) => {
                    this.props.history.push("/round/" + roundId);
                })   
    }

    // This will handle Cancel button click event.
    private handleCancel(e) {
        e.preventDefault();
        this.props.history.push("/");
    }

    // Returns the HTML Form to the render() method.
    private renderCreateForm() {
        return (
            <form onSubmit={this.handleSave} >
                <div className="form-group row" >
                    <input type="hidden" name="roundid" value={this.state.playerData.RoundId} />
                </div>
                <div className="form-group row" >
                    <input type="hidden" name="firstplayermove" value={this.state.playerData.FirstPlayerMove} />
                </div>
                <div className="form-group row" >
                    <input type="hidden" name="secondplayermove" value={this.state.playerData.SecondPlayerMove} />
                </div>
                <div className="form-group row" >
                    <input type="hidden" name="winner" value={this.state.playerData.Winner} />
                </div>
                < div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="FirstPlayerName">Player One Name</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="firstplayername" defaultValue={this.state.playerData.FirstPlayerName} required />
                    </div>
                </div >
                < div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="SecondPlayerName">Player Two Name</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="secondplayername" defaultValue={this.state.playerData.SecondPlayerName} required />
                    </div>
                </div >
                <div className="form-group">
                    <button type="submit" className="btn btn-default">Start</button>
                    <button className="btn" onClick={this.handleCancel}>Cancel</button>
                </div >
            </form >
        )
    }
}

export class PlayerData {
    RoundId: number = 0;
    FirstPlayerName: string = "";
    SecondPlayerName: string = "";
    FirstPlayerMove: string = "";
    SecondPlayerMove: string = "";
    Winner: string = "";

} 
