// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import './App.css';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Redirect,
  NavLink
} from 'react-router-dom';
import { useLayer1 } from './Layer1/Hooks';
import { useLayer5 } from './Layer5/Hooks';
import { DummyMainItemPage } from './Layer6/Pages/DummyMain/Item/DummyMainItemPage';
import { DummyMainListPage } from './Layer6/Pages/DummyMain/List/DummyMainListPage';
import { createAppSettings } from './AppSettings';

/**
 * Приложение.
 * @returns HTML.
 */
function App() {
  const appSettings = createAppSettings();

  useLayer1();
  useLayer5(appSettings.apiUrl);

  return (
    <Router>
      <div className="App">
        <header className="App-header">
          <div
            style={{
              display: 'flex',
              flexWrap: 'wrap',
              justifyContent: 'space-around',
              width: '100%'
            }}
          >
            <NavLink to="/dummy-main/list">Сущности "DummyMain"</NavLink>
            <NavLink to="/dummy-main/item/1">Сущность "DummyMain"</NavLink>
          </div>
          <hr />
          <Switch>
            <Redirect exact path="/" to="/dummy-main/list" />
            <Route exact path="/dummy-main/list">
              <DummyMainListPage />
            </Route>
            <Route exact path="/dummy-main/item/:id">
              <DummyMainItemPage />
            </Route>
          </Switch>
        </header>
      </div>
    </Router>
  );
}

export default App;
