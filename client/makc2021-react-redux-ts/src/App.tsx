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
import { useLayer1 } from './Layer1/Hooks';
import { useLayer5 } from './Layer5/Hooks';
import { TopMenuControl } from './Layer6/Controls/Menus/Top/TopMenuControl';
import { ContactsPage } from './Layer6/Pages/Contacts/ContactsPage';
import { DummyMainItemPage } from './Layer6/Pages/DummyMain/Item/DummyMainItemPage';
import { DummyMainListPage } from './Layer6/Pages/DummyMain/List/DummyMainListPage';
import { createAppSettings } from './AppSettings';
import React from 'react';
import { LocalizationService } from './Layer1/Localization/LocalizationService';
import { GlobalWaitingControl } from './Layer6/Controls/Waitings/Global/GlobalWaitingControl';

LocalizationService.start('en');

/**
 * Приложение.
 */
function App() {
  const appSettings = createAppSettings();

  useLayer1();
  useLayer5(appSettings.apiUrl);

  return (
    <React.Suspense fallback={<GlobalWaitingControl isVisible={true} />}>
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
            <Route exact path="/contacts">
              <ContactsPage />
            </Route>
          </Switch>
        </div>
      </Router>
    </React.Suspense>
  );
}

export default App;
