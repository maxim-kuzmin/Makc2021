// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TFunction } from 'i18next';
import { DefaultTableControlResource } from './DefaultTableControlResource';

/**
 * Модуль элемента управления "Таблица по умолчанию".
 */
export class DefaultTableControlModule {
  private _resourceGetter?: (
    functionToTranslate: TFunction
  ) => DefaultTableControlResource;

  /**
   * Ресурс. Получатель.
   */
  set resourceGetter(
    value: (functionToTranslate: TFunction) => DefaultTableControlResource
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
    ) as DefaultTableControlResource;
}
