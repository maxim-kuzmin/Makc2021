// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TFunction } from 'i18next';
import { QueryErrorMessageControlResource } from './QueryErrorMessageControlResource';

/**
 * Модуль элемента управления "Сообщение об ошибке запроса".
 */
export class QueryErrorMessageControlModule {
  private _resourceGetter?: (
    functionToTranslate: TFunction
  ) => QueryErrorMessageControlResource;

  /**
   * Ресурс. Получатель.
   */
  set resourceGetter(
    value: (functionToTranslate: TFunction) => QueryErrorMessageControlResource
  ) {
    this._resourceGetter = value;
  }

  /**
   * Создать ресурс.
   * @param functionToTranslate Функция перевода.
   * @returns Ресурс.
   */
  createResource = (functionToTranslate: TFunction) =>
    this._resourceGetter?.call(
      this,
      functionToTranslate
    ) as QueryErrorMessageControlResource;
}
