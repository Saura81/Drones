import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';

export class NavMenu extends React.Component<{}> {
    public render() {
        return <div className='main-nav'>
            <div className='navbar navbar-inverse'>
                <div className='navbar-header'>
                    <button type='button' className='navbar-toggle' data-toggle='collapse' data-target='.navbar-collapse'>
                        <span className='sr-only'>Toggle navigation</span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                    </button>
                    <Link className='navbar-brand' to={'/'}>Game Of Drones</Link>
                </div>
                <div className='clearfix'></div>
                <div className='navbar-collapse collapse'>
                    <ul className='nav navbar-nav'>
                        <li>
                            <NavLink to={'/'} exact activeClassName='active'>
                                <span className='glyphicon glyphicon-list-alt'></span> Check The rules
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/playerscreen'} activeClassName='active'>
                                <span className='glyphicon glyphicon-knight'></span> Players Select
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/fetchscoredata'} exact activeClassName='active'>
                                <span className='glyphicon glyphicon-th-list'></span> Scores
                            </NavLink>
                        </li>
                    </ul>
                </div>
            </div>
        </div>;
    }
}
