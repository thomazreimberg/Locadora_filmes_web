import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import Home from './pages/home';
import NotFound from './pages/NotFound';

export default function Routes() {
    return (
        <BrowserRouter>
          <Switch>
              <Route path="/" exact component={Home} />
              <Route path="*" element={<NotFound />} />
          </Switch>
        </BrowserRouter>
    )
}