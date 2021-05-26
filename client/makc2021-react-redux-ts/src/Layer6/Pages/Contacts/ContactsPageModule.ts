// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TFunction } from 'i18next';
import { ContactsPageResource } from './ContactsPageResource';

/**
 * Модуль страницы контактов.
 */
export class ContactsPageModule {
  private _resourceGetter?: (
    functionToTranslate: TFunction
  ) => ContactsPageResource;

  /**
   * Ресурс. Получатель.
   */
  public set resourceGetter(
    value: (functionToTranslate: TFunction) => ContactsPageResource
  ) {
    this._resourceGetter = value;
  }

  /**
   * Создать ресурс.
   * @param functionToTranslate Функция перевода.
   * @returns Ресурс.
   */
  public createResource(functionToTranslate: TFunction) {
    return this._resourceGetter?.call(
      this,
      functionToTranslate
    ) as ContactsPageResource;
  }
}
