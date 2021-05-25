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
import { createAppSettings } from './AppSettings';
import { LocalizationService } from './Layer1/Localization/LocalizationService';
import { useLayer6 } from './Layer6/Hooks';
import { Configurator } from './Configurator';
import { useTranslation } from 'react-i18next';

LocalizationService.start('en');

/**
 * Приложение.
 */
function App() {
  const appSettings = createAppSettings();

  const { i18n } = useTranslation();

  Configurator.Layer1.configureServices(i18n);

  Configurator.Layer5.configureServices(
    Configurator.Layer1,
    appSettings.apiUrl
  );

  useLayer6(
    Configurator.Layer6.Controls.Errors.Query.module,
    Configurator.Layer6.Controls.Menus.Top.module,
    Configurator.Layer6.Controls.Tables.Default.module,
    Configurator.Layer6.Pages.Contacts.module,
    Configurator.Layer6.Pages.DummyMain.Item.module,
    Configurator.Layer6.Pages.DummyMain.List.module,
    Configurator.Layer1.getModule()
  );

  return (
    <Router>
      <div className="App">
        <LanguageSwitcherControl />
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
  );
}

export default App;
