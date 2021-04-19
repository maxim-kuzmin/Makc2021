// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Сервис согласования.
 */
export class TimingService {
  private _isDelayNeeded = false;
  private _startDate?: Date;

  /**
   * Конструктор.
   * @param _delayInMilliseconds Задержка в миллисекундах.
   * @param _prolongationInMilliseconds Продление в миллисекундах.
   */
  constructor(
    private _delayInMilliseconds: number,
    private _prolongationInMilliseconds: number
  ) {}

  /**
   * Задержать.
   * @param action Действие.
   */
  delay(action: () => void) {
    this._isDelayNeeded = true;

    setTimeout(() => {
      if (this._isDelayNeeded) {
        this._startDate = new Date();

        action.call(this);
      }
    }, this._delayInMilliseconds);
  }

  /**
   * Продлить.
   * @param action Действие.
   */
  prolong(action: () => void) {
    this._isDelayNeeded = false;

    if (!this._startDate) {
      return;
    }

    const now = new Date();

    let duration = now.getTime() - this._startDate.getTime();

    this._startDate = undefined;

    if (duration < this._prolongationInMilliseconds) {
      setTimeout(() => {
        action.call(this);
      }, this._prolongationInMilliseconds - duration);
    } else {
      action.call(this);
    }
  }
}
