// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Пункт элемента управления "Меню".
 */
export interface MenuControlItem {
  /**
   * Дети.
   */
  children?: MenuControlItem[];

  /**
   * Признак открытия в новой вкладке.
   */
  isOpenInNewTab: boolean;

  /**
   * Признак внешнего пути.
   */
  isPathExternal: boolean;

  /**
   * Ключ.
   */
  key: string;

  /**
   * Родитель.
   */
  parent?: MenuControlItem;

  /**
   * Путь.
   */
  path: string;

  /**
   * Текст.
   */
  text: string;
}

/**
 * Создать пункт элемента управления "Меню".
 * @param key Ключ.
 * @returns Пункт элемента управления "Меню".
 */
export function createCommonMenuItem(key: string) {
  return {
    isOpenInNewTab: false,
    isPathExternal: false,
    key,
    path: '',
    text: ''
  } as MenuControlItem;
}
