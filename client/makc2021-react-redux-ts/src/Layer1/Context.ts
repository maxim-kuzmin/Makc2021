// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Module } from './Module';

/**
 * Контекст.
 */
export class Context {
  /**
   * Модуль.
   */
  readonly module = new Module();
}
