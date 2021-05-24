// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TFunction } from 'i18next';
import { useTranslation } from 'react-i18next';
import { Module } from './Module';
import { HttpService } from './Http/HttpService';
import { UrlService } from './Url/UrlService';
import { TimingFactory } from './Timing/TimingFactory';
import { LocalizationService } from './Localization/LocalizationService';
import { LocalizationLanguage } from './Localization/LocalizationLanguage';

/**
 * Использовать слой "Layer1".
 * @param module Модуль.
 */
export function useLayer1(module: Module) {
  let httpService: HttpService;

  useLayer1HttpService(module, () => {
    if (!httpService) {
      httpService = new HttpService();
    }

    return httpService;
  });

  let localizationLanguage: LocalizationLanguage;

  const { i18n } = useTranslation();

  useLayer1LocalizationLanguage(module, () => {
    if (!localizationLanguage) {
      localizationLanguage = new LocalizationLanguage(i18n);
    }
    return localizationLanguage;
  });

  useLayer1LocalizationService(module, (functionToTarnslate: TFunction) => {
    return new LocalizationService(functionToTarnslate);
  });

  let timingFactory: TimingFactory;

  useLayer1TimingFactory(module, () => {
    if (!timingFactory) {
      timingFactory = new TimingFactory();
    }

    return timingFactory;
  });

  let urlService: UrlService;

  useLayer1UrlService(module, () => {
    if (!urlService) {
      urlService = new UrlService();
    }

    return urlService;
  });
}

/**
 * Использовать сервис HTTP слоя "Layer1".
 * @param module Модуль.
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer1HttpService(
  module: Module,
  getter?: () => HttpService
) {
  if (getter) {
    module.httpServiceGetter = getter;
  }

  return module.httpService;
}

/**
 * Использовать язык локализации слоя "Layer1".
 * @param module Модуль.
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer1LocalizationLanguage(
  module: Module,
  getter?: () => LocalizationLanguage
) {
  if (getter) {
    module.localizationLanguageGetter = getter;
  }

  return module.localizationLanguage;
}

/**
 * Использовать сервис локализации слоя "Layer1".
 * @param module Модуль.
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer1LocalizationService(
  module: Module,
  getter?: (functionToTranslate: TFunction) => LocalizationService
) {
  if (getter) {
    module.localizationServiceGetter = getter;
  }

  return module.createLocalizationService;
}

/**
 * Использовать фабрику согласования слоя "Layer1".
 * @param module Модуль.
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer1TimingFactory(
  module: Module,
  getter?: () => TimingFactory
) {
  if (getter) {
    module.timingFactoryGetter = getter;
  }

  return module.timingFactory;
}

/**
 * Использовать сервис URL слоя "Layer1".
 * @param module Модуль.
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer1UrlService(module: Module, getter?: () => UrlService) {
  if (getter) {
    module.urlServiceGetter = getter;
  }

  return module.urlService;
}
