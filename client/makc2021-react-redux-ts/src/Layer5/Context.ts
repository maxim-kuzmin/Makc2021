// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Module } from './Module';
import { PagesContext } from './Pages/PagesContext';

/**
 * Контекст.
 */
export class Context {
  /**
   * Модуль.
   */
  readonly module = new Module();

  /**
   * Страницы.
   */
  readonly Pages = new PagesContext();
}
