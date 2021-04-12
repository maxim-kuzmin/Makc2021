// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Counter } from './features/counter/Counter';
import './App.css';
import { BrowserRouter as Router, Link, Switch, Route } from 'react-router-dom';
import { DummyMainItemPage } from './Layer6/Pages/DummyMain/Item/DummyMainItemPage';
import { DummyMainListPage } from './Layer6/Pages/DummyMain/List/DummyMainListPage';
import { appLayer5Module } from './Layer5/Module';
import { appLayer1Module } from './Layer1/Module';
import { createAppSettings } from './AppSettings';

/**
 * Приложение.
 * @returns HTML.
 */
function App() {
  const appSettings = createAppSettings();

  appLayer1Module.configure();
  appLayer5Module.configure(appSettings.apiUrl);

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
            <Link to="/">Home</Link>
            <Link to="/counter">Counter</Link>
            <Link to="/dummy-main/item/1">Сущность "DummyMain"</Link>
            <Link to="/dummy-main/list">Сущности "DummyMain"</Link>
          </div>
          <hr />
          <Switch>
            <Route exact path="/">
              <Home />
            </Route>
            <Route exact path="/counter">
              <Counter />
            </Route>
            <Route exact path="/dummy-main/item/:id">
              <DummyMainItemPage />
            </Route>
            <Route exact path="/dummy-main/list">
              <DummyMainListPage />
            </Route>
          </Switch>
          <p>
            Edit <code>src/App.tsx</code> and save to reload.
          </p>
          <span>
            <span>Learn </span>
            <a
              className="App-link"
              href="https://reactjs.org/"
              target="_blank"
              rel="noopener noreferrer"
            >
              React
            </a>
            <span>, </span>
            <a
              className="App-link"
              href="https://redux.js.org/"
              target="_blank"
              rel="noopener noreferrer"
            >
              Redux
            </a>
            <span>, </span>
            <a
              className="App-link"
              href="https://redux-toolkit.js.org/"
              target="_blank"
              rel="noopener noreferrer"
            >
              Redux Toolkit
            </a>
            ,<span> and </span>
            <a
              className="App-link"
              href="https://react-redux.js.org/"
              target="_blank"
              rel="noopener noreferrer"
            >
              React Redux
            </a>
          </span>
        </header>
      </div>
    </Router>
  );
}

export default App;

function Home() {
  return (
    <div>
      <h2>Home</h2>
    </div>
  );
}
