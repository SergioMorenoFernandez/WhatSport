import { RouteInfo } from './sidebar.metadata';

export const ROUTES: RouteInfo[] = [
 
  {
    path: '/dashboard',
    title: 'Dashboard',
    icon: 'bi bi-speedometer2',
    class: '',
    extralink: false,
    submenu: []
  },
  // {
  //   path: '/component/club',
  //   title: 'Club',
  //   icon: 'bi bi-patch-check',
  //   class: '',
  //   extralink: false,
  //   submenu: []
  // },
  {
    path: '/component/match',
    title: 'Match',
    icon: 'bi bi-menu-app',
    class: '',
    extralink: false,
    submenu: []
  },
  {
    path: '/component/friends',
    title: 'Friend',
    icon: 'bi bi-people',
    class: '',
    extralink: false,
    submenu: []
  }
];
