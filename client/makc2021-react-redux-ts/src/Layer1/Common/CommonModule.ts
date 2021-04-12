// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Общий модуль.
 */
export abstract class CommonModule {
  private _isConfigured = false;

  /**
   * Конструктор.
   * @param _moduleName Имя модуля.
   */
  constructor(private _moduleName: string) {}

  protected completeConfiguration() {
    this._isConfigured = true;
  }

  /**
   * Выбросить ошибку, если модуль не настроен.
   */
  throwErrorIfModuleIsNotConfigured() {
    if (!this._isConfigured) {
      throw new Error(`Module ${this._moduleName} is not configured`);
    }
  }
}
