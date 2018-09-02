using Algorithms.BinaryTree;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Algorithms.UnitTests.Tree {
    public class TreeDataStructuresTests {

        private TreeDataStructures _treeObjectsNode;

        [SetUp]
        public void SetUp() {
            _treeObjectsNode = new TreeDataStructures();
        }

        [TestCaseSource(nameof(GetTestCase))]
        public void Test_tree(List<NodesData> data, int node, Node expected) {
             _treeObjectsNode.RetrieveFullTree(node, data);
        }

        private static IEnumerable<object> GetTestCase() {
            yield return new TestCaseData(CreateData(), 1, CreateExpectedNode1());
            yield return new TestCaseData(CreateData(), 2, CreateExpectedNode2());
            yield return new TestCaseData(CreateData(), 7, CreateExpectedNode7());
        }

        private static object CreateExpectedNode1() {
            return new Node {
                Id = 1,
                LinkedNodes = new Node[] {
                    new Node {
                        Id = 3,
                        LinkedNodes = new Node[] {
                            new Node {
                                Id = 4,
                                LinkedNodes = new Node[] {
                                    new Node {
                                        Id = 8,
                                        LinkedNodes = null
                                    }
                                }
                            },
                            new Node {
                                Id = 5,
                                LinkedNodes = new Node[] {
                                    new Node {
                                        Id = 8,
                                        LinkedNodes = null
                                    }
                                }
                            },
                            new Node {
                                Id = 6,
                                LinkedNodes = new Node[] {
                                    new Node {
                                        Id = 8,
                                        LinkedNodes = null
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        private static object CreateExpectedNode2() {
            return new Node {
                Id = 2,
                LinkedNodes = new Node[] {
                    new Node {
                        Id = 3,
                        LinkedNodes = new Node[] {
                            new Node {
                                Id = 4,
                                LinkedNodes = new Node[] {
                                    new Node {
                                        Id = 8,
                                        LinkedNodes = null
                                    }
                                }
                            },
                            new Node {
                                Id = 5,
                                LinkedNodes = new Node[] {
                                    new Node {
                                        Id = 8,
                                        LinkedNodes = null
                                    }
                                }
                            },
                            new Node {
                                Id = 6,
                                LinkedNodes = new Node[] {
                                    new Node {
                                        Id = 8,
                                        LinkedNodes = null
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        private static object CreateExpectedNode7() {
            return new Node {
                Id = 7,
                LinkedNodes = new Node[] {
                    new Node {
                        Id = 6,
                        LinkedNodes = new Node[] {
                            new Node {
                                Id = 8,
                                LinkedNodes = null
                            }
                        }
                    },
                }
            };
        }

        private static List<NodesData> CreateData() {
            return new List<NodesData> {
                new NodesData { Id = new Guid("2CD83141-08A0-4B91-AB5B-B3D2A4A7007B"), FromNodeId = 1, ToNodeId = 3 },
                new NodesData { Id = new Guid("1BB30262-1E26-4D78-A6D3-4C01BEEA63A1"), FromNodeId = 2, ToNodeId = 3 },
                new NodesData { Id = new Guid("AB2A2377-7537-4703-AA89-F80672B56D20"), FromNodeId = 3, ToNodeId = 4 },
                new NodesData { Id = new Guid("03667173-2BC8-49AA-89FA-582E22ABA4EF"), FromNodeId = 4, ToNodeId = 8 },
                new NodesData { Id = new Guid("4E51CA97-D226-437C-B891-8C24B1AC984C"), FromNodeId = 5, ToNodeId = 8 },
                new NodesData { Id = new Guid("5CD47D9D-EB88-4027-B2FC-DE10B148064B"), FromNodeId = 6, ToNodeId = 8 },
                new NodesData { Id = new Guid("2CF33F2E-1BE2-4EA2-BC4C-5F5B39B353BB"), FromNodeId = 7, ToNodeId = 6 },
                new NodesData { Id = new Guid("FF81B02D-4E72-4A33-9FBC-9D4E3C5998F1"), FromNodeId = 3, ToNodeId = 5 },
                new NodesData { Id = new Guid("CBBD7C22-A328-4147-BD00-9C49B79DCDD0"), FromNodeId = 3, ToNodeId = 6 },
            };
        }
    }
}
