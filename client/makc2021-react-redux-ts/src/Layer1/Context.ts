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
   * Получить модуль.
   * @returns Модуль.
   */
  getModule() {
    return this._module;
  }

  /**
   * Настроить сервисы.
   * @param i18n Интернационализация.
   */
  configureServices(i18n: i18n) {
    let httpService = new Lazy<HttpService>(() => new HttpService());

    let localizationLanguage = new Lazy<LocalizationLanguage>(
      () => new LocalizationLanguage(i18n)
    );

    let timingFactory = new Lazy<TimingFactory>(() => new TimingFactory());

    let urlService = new Lazy<UrlService>(() => new UrlService());

    this._module.httpServiceGetter = () => {
      return httpService.value;
    };

    this._module.localizationLanguageGetter = () => {
      return localizationLanguage.value;
    };

    this._module.localizationServiceGetter = (
      functionToTarnslate: TFunction
    ) => {
      return new LocalizationService(functionToTarnslate);
    };

    this._module.timingFactoryGetter = () => {
      return timingFactory.value;
    };

    this._module.urlServiceGetter = () => {
      return urlService.value;
    };
  }
}
