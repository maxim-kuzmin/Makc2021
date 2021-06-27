// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TimingFactory } from '../../Timing/TimingFactory';

/**
 * Общее хранилище страницы.
 */
export abstract class CommonPageStore {
  /**
   * Конструктор.
   * @param appTimingFactory Фабрика согласования.
   */
  constructor(protected readonly appTimingFactory: TimingFactory) {}
}
