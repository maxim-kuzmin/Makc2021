// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Lazy } from 'src/Layer1/Lazy';
import { TopMenuControlModule } from './TopMenuControlModule';
import { TopMenuControlStore } from './TopMenuControlStore';

/**
 * Контекст элемента управления "Верхнее меню".
 */
export class TopMenuControlContext {
  private _module = new TopMenuControlModule();

  /**
   * Настроить сервисы.
   */
  configureServices() {
    const instanceOfStore = new Lazy<TopMenuControlStore>(
      () => new TopMenuControlStore()
    );
    this._module.storeGetter = () => instanceOfStore.value;
  }

  /**
   * Получить модуль.
   * @returns Модуль.
   */
  getModule() {
    return this._module;
  }
}
