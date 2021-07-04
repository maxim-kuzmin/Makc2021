// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TFunction } from 'i18next';
import { QueryNotificationControlResource } from './QueryNotificationControlResource';

/**
 * Модуль элемента управления "Извещение запроса".
 */
export class QueryNotificationControlModule {
  private _resourceGetter?: (
    functionToTranslate: TFunction
  ) => QueryNotificationControlResource;

  /**
   * Ресурс. Получатель.
   */
  set resourceGetter(
    value: (functionToTranslate: TFunction) => QueryNotificationControlResource
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
    ) as QueryNotificationControlResource;
}
