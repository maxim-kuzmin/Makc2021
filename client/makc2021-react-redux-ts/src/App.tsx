// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Redirect
} from 'react-router-dom';
import { useLayer1 } from './Layer1/Hooks';
import { useLayer5 } from './Layer5/Hooks';
import { TopMenuControl } from 'src/Layer6/Controls/Menus/Top/TopMenuControl';
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
        <TopMenuControl />
        <Switch>
          <Redirect exact path="/" to="/dummy-main/list" />
          <Route exact path="/dummy-main/list">
            <DummyMainListPage />
          </Route>
          <Route exact path="/dummy-main/item/:id?">
            <DummyMainItemPage />
          </Route>
        </Switch>
      </div>
    </Router>
  );
}

export default App;
