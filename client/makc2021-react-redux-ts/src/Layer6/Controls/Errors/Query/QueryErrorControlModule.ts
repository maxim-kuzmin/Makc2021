// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TFunction } from 'i18next';
import { QueryErrorControlResource } from './QueryErrorControlResource';

/**
 * Модуль элемента управления "Ошибка запроса".
 */
export class QueryErrorControlModule {
  private _resourceGetter?: (
    functionToTranslate: TFunction
  ) => QueryErrorControlResource;

  /**
   * Ресурс. Получатель.
   */
  set resourceGetter(
    value: (functionToTranslate: TFunction) => QueryErrorControlResource
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
    ) as QueryErrorControlResource;
}
