// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Context as Layer1Context } from 'src/Layer1/Context';
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
   * @param contextOfLayer1 Контекст слоя "Layer1".
   */
  configureServices(contextOfLayer1: Layer1Context) {
    this.Contacts.configureServices(contextOfLayer1);
    this.DummyMain.configureServices(contextOfLayer1);
  }
}
