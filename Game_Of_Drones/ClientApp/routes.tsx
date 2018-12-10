import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/navigation/Layout';
import { Home } from './components/navigation/Home';
import { FetchScoreData } from './components/game/FetchScoresData';
//import { FetchCurrentGameScore } from './components/game/FetchCurrentGameScore';
import { PlayerScreen } from './components/game/PlayerScreen';
import { Round } from './components/game/Round';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/fetchscoredata' component={FetchScoreData} />
    <Route path='/playerscreen' component={PlayerScreen} />
    <Route path='/round/:roundId' component={Round} />
</Layout>;
