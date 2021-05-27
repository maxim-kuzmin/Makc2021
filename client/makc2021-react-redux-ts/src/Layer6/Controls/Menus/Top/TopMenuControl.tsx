// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import Nav from 'react-bootstrap/Nav';
import { LinkContainer } from 'react-router-bootstrap';
import { useLocation } from 'react-router-dom';
import { Configurator } from 'src/Configurator';
import { useResource } from 'src/Layer1/Localization/LocalizationHooks';

/**
 * Элемент управления "Верхнее меню".
 */
export function TopMenuControl() {
  const resource = useResource(
    Configurator.Layer6.Controls.Menus.Top.getModule().createResource,
    'Layer6/Controls/Menus/Top/TopMenuControl'
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
