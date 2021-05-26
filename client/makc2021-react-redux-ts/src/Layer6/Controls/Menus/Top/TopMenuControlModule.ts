// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TFunction } from 'i18next';
import { TopMenuControlResource } from './TopMenuControlResource';

/**
 * Модуль элемента управления "Верхнее меню".
 */
export class TopMenuControlModule {
  private _resourceGetter?: (
    functionToTranslate: TFunction
  ) => TopMenuControlResource;

  /**
   * Ресурс. Получатель.
   */
  public set resourceGetter(
    value: (functionToTranslate: TFunction) => TopMenuControlResource
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
    ) as TopMenuControlResource;
  }
}
