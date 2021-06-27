// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { DummyMainEntityObject } from 'src/Layer3/Sample/Entities/DummyMainEntityObject';

/**
 * Выходные данные запроса на получение элемента в домене.
 */
export interface DomainItemGetQueryOutput {
  /**
   * Объект сущности "DummyMain".
   */
  objectOfDummyMainEntity: DummyMainEntityObject;
}

/**
 * Создать выходные данные запроса на получение элемента в домене.
 * @returns Выходные данные запроса на получение элемента в домене.
 */
export function createDomainItemGetQueryOutput() {
  return {} as DomainItemGetQueryOutput;
}
