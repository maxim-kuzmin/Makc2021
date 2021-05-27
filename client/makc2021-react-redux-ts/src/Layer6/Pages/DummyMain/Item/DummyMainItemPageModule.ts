// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TFunction } from 'i18next';
import { DummyMainItemPageResource } from './DummyMainItemPageResource';

/**
 * Модуль страницы сущности "DummyMain".
 */
export class DummyMainItemPageModule {
  private _resourceGetter?: (
    functionToTranslate: TFunction
  ) => DummyMainItemPageResource;

  /**
   * Ресурс. Получатель.
   */
  set resourceGetter(
    value: (functionToTranslate: TFunction) => DummyMainItemPageResource
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
    ) as DummyMainItemPageResource;
}
