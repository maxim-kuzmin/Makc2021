// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { i18n, TFunction } from 'i18next';
import { HttpService } from './Http/HttpService';
import { Lazy } from './Lazy';
import { LocalizationLanguage } from './Localization/LocalizationLanguage';
import { LocalizationService } from './Localization/LocalizationService';
import { Module } from './Module';
import { TimingFactory } from './Timing/TimingFactory';
import { UrlService } from './Url/UrlService';

/**
 * Контекст.
 */
export class Context {
  private readonly _module = new Module();

  /**
   * Настроить сервисы.
   * @param i18n Интернационализация.
   */
  configureServices(i18n: i18n) {
    const instanceOfHttpService = new Lazy<HttpService>(
      () => new HttpService()
    );
    this._module.httpServiceGetter = () => instanceOfHttpService.value;

    const instanceOfLocalizationLanguage = new Lazy<LocalizationLanguage>(
      () => new LocalizationLanguage(i18n)
    );
    this._module.localizationLanguageGetter = () =>
      instanceOfLocalizationLanguage.value;

    const instanceOfTimingFactory = new Lazy<TimingFactory>(
      () => new TimingFactory()
    );
    this._module.timingFactoryGetter = () => instanceOfTimingFactory.value;

    const instanceOfUrlService = new Lazy<UrlService>(() => new UrlService());
    this._module.urlServiceGetter = () => instanceOfUrlService.value;

    this._module.localizationServiceGetter = (
      functionToTarnslate: TFunction
    ) => {
      return new LocalizationService(functionToTarnslate);
    };
  }

  /**
   * Получить модуль.
   * @returns Модуль.
   */
  getModule() {
    return this._module;
  }
}
