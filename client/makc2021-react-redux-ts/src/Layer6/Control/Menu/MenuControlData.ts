// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { MenuControlItem } from './MenuControlItem';

/**
 * Данные элемента управления "Меню".
 */
export class MenuControlData {
  private readonly _lookupByKey = new Map<string, MenuControlItem>();

  /**
   * Конструктор.
   * @param items Пункты.
   */
  constructor(public items: MenuControlItem[]) {
    this.loadItems(items);
  }
  /**
   * Получить пункт по ключу.
   * @param key Ключ.
   * @returns Пункт.
   */
  getItemByKey(key: string) {
    return this._lookupByKey.get(key);
  }

  /**
   * Получить пункт с предками по ключу.
   * @param key Ключ.
   * @returns Пункты.
   */
  getItemWithAncestorsByKey(key: string) {
    const item = this.getItemByKey(key);

    let result: MenuControlItem[] = [];

    if (item) {
      if (item.parent) {
        result = this.getItemWithAncestorsByKey(item.parent.key);
      }

      if (!result) {
        result = [];
      }

      result.push(item);
    }

    return result;
  }

  private loadItems(items?: MenuControlItem[]) {
    if (!items) {
      return;
    }

    for (const item of items) {
      this._lookupByKey.set(item.key, item);

      this.loadItems(item.children);
    }
  }
}
