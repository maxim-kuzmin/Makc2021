// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { ContactsPageContext } from './Contacts/ContactsPageContext';
import { DummyMainPagesContext } from './DummyMain/DummyMainPagesContext';

/**
 * Контекст страниц.
 */
export class PagesContext {
  /**
   * Контакты.
   */
  readonly Contacts = new ContactsPageContext();

  /**
   * Сущность "DummyMain".
   */
  readonly DummyMain = new DummyMainPagesContext();

  /**
   * Настроить сервисы.
   */
  configureServices() {
    this.Contacts.configureServices();
    this.DummyMain.configureServices();
  }
}
