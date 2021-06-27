// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { PropsWithChildren } from 'react';
import { matchPath } from 'react-router';
import { useLocation } from 'react-router-dom';
import { TopMenuItemControlProps } from './TopMenuItemControlProps';
import { TopMenuItemLinkControl } from './Link/TopMenuItemLinkControl';
import { Nav } from 'react-bootstrap';

/**
 * Элемент управления "Пункт верхнего меню".
 */
export function TopMenuItemControl({
  iconClassName,
  menuItem
}: PropsWithChildren<TopMenuItemControlProps>) {
  const location = useLocation();

  const getClassName = () => {
    return matchPath(location.pathname, menuItem.path) ? 'active' : '';
  };

  return (
    <Nav.Item className={getClassName()}>
      <TopMenuItemLinkControl
        iconClassName={iconClassName}
        menuItem={menuItem}
      />
    </Nav.Item>
  );
}
