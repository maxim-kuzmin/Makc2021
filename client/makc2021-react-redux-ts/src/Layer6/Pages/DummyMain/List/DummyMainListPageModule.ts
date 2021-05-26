// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TFunction } from 'i18next';
import { DummyMainListPageResource } from './DummyMainListPageResource';

/**
 * Модуль страницы сущностей "DummyMain".
 */
export class DummyMainListPageModule {
  private _resourceGetter?: (
    functionToTranslate: TFunction
  ) => DummyMainListPageResource;

  /**
   * Ресурс. Получатель.
   */
  public set resourceGetter(
    value: (functionToTranslate: TFunction) => DummyMainListPageResource
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
    ) as DummyMainListPageResource;
  }
}
