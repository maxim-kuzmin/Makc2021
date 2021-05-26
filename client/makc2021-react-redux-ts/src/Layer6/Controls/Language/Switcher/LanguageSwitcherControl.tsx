// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import FormControl from 'react-bootstrap/FormControl';
import { Configurator } from 'src/Configurator';

/**
 * Элемент управления "Переключатель языка".
 */
export function LanguageSwitcherControl() {
  const language = Configurator.Layer1.getModule().localizationLanguage;

  return (
    <FormControl
      as="select"
      value={language.current}
      onChange={(e) => language.change(e.target.value)}
      style={{ width: '7em' }}
    >
      <option value="en">English</option>
      <option value="ru">Русский</option>
    </FormControl>
  );
}
