import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/navigation/Layout';
import { Home } from './components/navigation/Home';
import { FetchScoreData } from './components/FetchScoresData';
import { Counter } from './components/Counter';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/counter' component={ Counter } />
    <Route path='/fetchscoredata' component={FetchScoreData} />
</Layout>;
