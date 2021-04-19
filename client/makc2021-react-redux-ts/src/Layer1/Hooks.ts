// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Module } from './Module';
import { HttpService } from './Http/HttpService';
import { UrlService } from './Url/UrlService';
import { TimingFactory } from './Timing/TimingFactory';

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
