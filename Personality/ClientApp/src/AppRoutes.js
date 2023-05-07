import Home from "./components/Home";
import Test from "./components/Test";
import Result from "./components/Result";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/test',
    element: <Test />
  },
  {
    path: '/result/:id',
    element: <Result />
  }
];

export default AppRoutes;