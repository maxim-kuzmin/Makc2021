// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TFunction } from 'i18next';
import { HttpService } from './Http/HttpService';
import { LocalizationLanguage } from './Localization/LocalizationLanguage';
import { LocalizationService } from './Localization/LocalizationService';
import { TimingFactory } from './Timing/TimingFactory';
import { UrlService } from './Url/UrlService';

/**
 * Модуль.
 */
export class Module {
  private _httpServiceGetter?: () => HttpService;

  private _localizationLanguageGetter?: () => LocalizationLanguage;

  private _localizationServiceGetter?: (
    functionToTranslate: TFunction
  ) => LocalizationService;

  private _timingFactoryGetter?: () => TimingFactory;

  private _urlServiceGetter?: () => UrlService;

  /**
   * Сервис HTTP.
   */
  get httpService() {
    return this._httpServiceGetter?.call(this) as HttpService;
  }

  /**
   * Сервис HTTP. Получатель.
   */
  set httpServiceGetter(value: () => HttpService) {
    this._httpServiceGetter = value;
  }

  /**
   * Язык локализации.
   */
  get localizationLanguage() {
    return this._localizationLanguageGetter?.call(this) as LocalizationLanguage;
  }

  /**
   * Язык локализации. Получатель.
   */
  set localizationLanguageGetter(value: () => LocalizationLanguage) {
    this._localizationLanguageGetter = value;
  }

  /**
   * Сервис локализации. Получатель.
   */
  set localizationServiceGetter(
    value: (functionToTranslate: TFunction) => LocalizationService
  ) {
    this._localizationServiceGetter = value;
  }

  /**
   * Фабрика согласования.
   */
  get timingFactory() {
    return this._timingFactoryGetter?.call(this) as TimingFactory;
  }

  /**
   * Фабрика согласования. Получатель.
   */
  set timingFactoryGetter(value: () => TimingFactory) {
    this._timingFactoryGetter = value;
  }

  /**
   * Сервис URL.
   */
  get urlService() {
    return this._urlServiceGetter?.call(this) as UrlService;
  }

  /**
   * Сервис URL. Получатель.
   */
  set urlServiceGetter(value: () => UrlService) {
    this._urlServiceGetter = value;
  }

  /**
   * Создать сервис локализации.
   * @param functionToTranslate Функция перевода.
   * @returns Сервис локализации.
   */
  createLocalizationService = (functionToTranslate: TFunction) =>
    this._localizationServiceGetter?.call(
      this,
      functionToTranslate
    ) as LocalizationService;
}
