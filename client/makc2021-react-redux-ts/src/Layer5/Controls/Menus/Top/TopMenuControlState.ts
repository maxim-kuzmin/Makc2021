// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Состояние элемента управления "Верхнее меню".
 */
export interface TopMenuControlState {
  /**
   * Ключ текущего пункта.
   */
  currentItemKey: string;
}

/**
 * Создать состояние элемента управления "Верхнее меню".
 * @returns Состояние элемента управления "Верхнее меню".
 */
export function createTopMenuControlState() {
  return {
    currentItemKey: ''
  } as TopMenuControlState;
}
