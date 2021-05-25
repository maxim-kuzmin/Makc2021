// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Ленивый. Создаёт значение в момент обращения к свойству value.
 * @template T Тип значения.
 */
export class Lazy<TValue> {
  private _value?: TValue;

  /**
   * Конструктор.
   * @param _valueGetter Получатель значения.
   */
  constructor(private _valueGetter: () => TValue) {}

  /**
   * Значение.
   */
  get value() {
    if (!this._value) {
      this._value = this._valueGetter.call(this);
    }

    return this._value as TValue;
  }
}
