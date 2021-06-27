// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TFunction } from 'i18next';
import { TopMenuControlResource } from './TopMenuControlResource';
import { TopMenuControlService } from './TopMenuControlService';

/**
 * Модуль элемента управления "Верхнее меню".
 */
export class TopMenuControlModule {
  private _serviceGetter?: () => TopMenuControlService;

  private _resourceGetter?: (
    functionToTranslate: TFunction
  ) => TopMenuControlResource;

  /**
   * Ресурс. Получатель.
   */
  set resourceGetter(
    value: (functionToTranslate: TFunction) => TopMenuControlResource
  ) {
    this._resourceGetter = value;
  }

  /**
   * Сервис.
   */
  get service() {
    return this._serviceGetter?.call(this) as TopMenuControlService;
  }

  /**
   * Сервис. Получатель.
   */
  set serviceGetter(value: () => TopMenuControlService) {
    this._serviceGetter = value;
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
    ) as TopMenuControlResource;
}
