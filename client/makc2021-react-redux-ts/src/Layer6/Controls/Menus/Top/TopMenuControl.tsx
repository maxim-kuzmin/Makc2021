// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import Nav from 'react-bootstrap/Nav';
import { useTranslation } from 'react-i18next';
import { LinkContainer } from 'react-router-bootstrap';
import { useLocation } from 'react-router-dom';
import { Configurator } from 'src/Configurator';

/**
 * Элемент управления "Верхнее меню".
 */
export function TopMenuControl() {
  const { t } = useTranslation('Layer6/Controls/Menus/Top/TopMenuControl');

  const resource = Configurator.Layer6.Controls.Menus.Top.getModule().createResource(
    Configurator.Layer1.getModule().createLocalizationService(t)
  );

  const location = useLocation();

  return (
    <Nav className="justify-content-center" activeKey={location.pathname}>
      <Nav.Item>
        <LinkContainer to="/dummy-main/list">
          <Nav.Link>{resource.getDummyMainListPageLinkTitle()}</Nav.Link>
        </LinkContainer>
      </Nav.Item>
      <Nav.Item>
        <LinkContainer to="/dummy-main/item">
          <Nav.Link>{resource.getDummyMainItemPageLinkTitle()}</Nav.Link>
        </LinkContainer>
      </Nav.Item>
      <Nav.Item>
        <LinkContainer to="/contacts">
          <Nav.Link>{resource.getContactsPageLinkTitle()}</Nav.Link>
        </LinkContainer>
      </Nav.Item>
    </Nav>
  );
}
