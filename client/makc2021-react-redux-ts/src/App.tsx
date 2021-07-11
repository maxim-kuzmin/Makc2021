// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import './App.css';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Redirect
} from 'react-router-dom';
import { LanguageSwitcherControl } from './Layer6/Controls/Language/Switcher/LanguageSwitcherControl';
import { TopMenuControl } from './Layer6/Controls/Menus/Top/TopMenuControl';
import { ContactsPage } from './Layer6/Pages/Contacts/ContactsPage';
import { DummyMainItemPage } from './Layer6/Pages/DummyMain/Item/DummyMainItemPage';
import { DummyMainListPage } from './Layer6/Pages/DummyMain/List/DummyMainListPage';
import { Configurator } from './Configurator';
import { Context } from './Context';
import { QueryNotificationControl } from './Layer6/Controls/Notifications/Query/QueryNotificationControl';
import { GlobalWaitingControl } from './Layer6/Controls/Waitings/Global/GlobalWaitingControl';

Configurator.configureServices();

/**
 * Приложение.
 */
function App() {
  Configurator.useServices();

  return (
    <Context.Provider value={Configurator.getContextValue()}>
      <div className="App">
        <LanguageSwitcherControl />
        <Router>
          <TopMenuControl />
          <QueryNotificationControl />
          <Switch>
            <Redirect exact path="/" to="/dummy-main/list" />
            <Route exact path="/dummy-main/list">
              <DummyMainListPage />
            </Route>
            <Route exact path="/dummy-main/item/:id?">
              <DummyMainItemPage />
            </Route>
            <Route exact path="/contacts">
              <ContactsPage />
            </Route>
          </Switch>
        </Router>
      </div>
      <GlobalWaitingControl />
    </Context.Provider>
  );
}

export default App;
