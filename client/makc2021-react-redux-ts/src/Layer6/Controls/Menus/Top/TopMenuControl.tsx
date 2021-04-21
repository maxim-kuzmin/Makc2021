// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import Nav from 'react-bootstrap/Nav';
import { LinkContainer } from 'react-router-bootstrap';
import { useLocation } from 'react-router-dom';
import { useTranslation } from 'react-i18next';

/**
 * Элемент управления "Верхнее меню".
 */
export function TopMenuControl() {
  const { t } = useTranslation();

  const location = useLocation();

  return (
    <Nav className="justify-content-center" activeKey={location.pathname}>
      <Nav.Item>
        <Nav.Link href="/dummy-main/list">{t('Список')}</Nav.Link>
      </Nav.Item>
      <Nav.Item>
        <LinkContainer to="/dummy-main/item">
          <Nav.Link>{t('Элемент')}</Nav.Link>
        </LinkContainer>
      </Nav.Item>
      <Nav.Item>
        <Nav.Link href="/contacts">{t('Контакты')}</Nav.Link>
      </Nav.Item>
    </Nav>
  );
}
