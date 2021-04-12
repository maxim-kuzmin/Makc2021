// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Module as Layer1Module } from '../Layer1/Module';
import { Module as Layer5Module } from './Module';

/**
 * Конфигуратор.
 */
export class Configurator {
  private static _apiUrl = 'http://localhost:5000/api/';

  /**
   * Настроить.
   */
  static configure() {
    Layer1Module.configure();
    Layer5Module.configure(this._apiUrl, Layer1Module.get().httpService);
  }
}
