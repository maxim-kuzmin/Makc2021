// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TFunction } from 'i18next';
import { QuerySuccessMessageControlResource } from './QuerySuccessMessageControlResource';

/**
 * Модуль элемента управления "Сообщение об успехе запроса".
 */
export class QuerySuccessMessageControlModule {
  private _resourceGetter?: (
    functionToTranslate: TFunction
  ) => QuerySuccessMessageControlResource;

  /**
   * Ресурс. Получатель.
   */
  set resourceGetter(
    value: (
      functionToTranslate: TFunction
    ) => QuerySuccessMessageControlResource
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
    ) as QuerySuccessMessageControlResource;
}
