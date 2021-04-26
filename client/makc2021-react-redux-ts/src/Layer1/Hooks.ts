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
 */
export function useLayer1() {
  let httpService: HttpService;

  useLayer1HttpService(() => {
    if (!httpService) {
      httpService = new HttpService();
    }

    return httpService;
  });

  let localizationLanguage: LocalizationLanguage;

  const { i18n } = useTranslation();

  useLayer1LocalizationLanguage(() => {
    if (!localizationLanguage) {
      localizationLanguage = new LocalizationLanguage(i18n);
    }
    return localizationLanguage;
  });

  useLayer1LocalizationService((functionToTarnslate: TFunction) => {
    return new LocalizationService(functionToTarnslate);
  });

  let timingFactory: TimingFactory;

  useLayer1TimingFactory(() => {
    if (!timingFactory) {
      timingFactory = new TimingFactory();
    }

    return timingFactory;
  });

  let urlService: UrlService;

  useLayer1UrlService(() => {
    if (!urlService) {
      urlService = new UrlService();
    }

    return urlService;
  });
}

/**
 * Использовать сервис HTTP слоя "Layer1".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer1HttpService(getter?: () => HttpService) {
  const module = Module.get();

  if (getter) {
    module.httpServiceGetter = getter;
  }

  return module.httpService;
}

/**
 * Использовать язык локализации слоя "Layer1".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer1LocalizationLanguage(
  getter?: () => LocalizationLanguage
) {
  const module = Module.get();

  if (getter) {
    module.localizationLanguageGetter = getter;
  }
  return module.localizationLanguage;
}

/**
 * Использовать сервис локализации слоя "Layer1".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer1LocalizationService(
  getter?: (functionToTranslate: TFunction) => LocalizationService
) {
  const module = Module.get();

  if (getter) {
    module.localizationServiceGetter = getter;
  }

  return module.createLocalizationService;
}

/**
 * Использовать фабрику согласования слоя "Layer1".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer1TimingFactory(getter?: () => TimingFactory) {
  const module = Module.get();

  if (getter) {
    module.timingFactoryGetter = getter;
  }

  return module.timingFactory;
}

/**
 * Использовать сервис URL слоя "Layer1".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer1UrlService(getter?: () => UrlService) {
  const module = Module.get();

  if (getter) {
    module.urlServiceGetter = getter;
  }

  return module.urlService;
}
