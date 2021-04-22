// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useTranslation } from 'react-i18next';
import { TopMenuControlResource } from './Controls/Menus/Top/TopMenuControlResource';
import { Module as Layer1Module } from 'src/Layer1/Module';
import { Module } from './Module';
import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';

/**
 * Использовать слой "Layer6".
 */
export function useLayer6() {
  useLayer6TopMenuControlResource(
    (localizationService: LocalizationService) => {
      return new TopMenuControlResource(localizationService);
    }
  );
}

/**
 * Использовать ресурс элемента управления "Верхнее меню". слоя "Layer1".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer6TopMenuControlResource(
  getter?: (localizationService: LocalizationService) => TopMenuControlResource
) {
  const { t } = useTranslation('Layer6TopMenuControl');

  const module = Module.get();

  if (getter) {
    module.resourceOfTopMenuControlGetter = getter;
  }

  return module.createResourceOfTopMenuControl(
    Layer1Module.get().createLocalizationService(t)
  );
}
