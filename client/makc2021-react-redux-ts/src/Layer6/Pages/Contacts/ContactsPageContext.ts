// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { ContactsPageModule } from './ContactsPageModule';

/**
 * Контекст страницы контактов.
 */
export class ContactsPageContext {
  /**
   * Модуль.
   */
  readonly module = new ContactsPageModule();
}
