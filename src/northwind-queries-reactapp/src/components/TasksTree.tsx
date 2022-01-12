import {useState} from 'react'
import {Treebeard, TreeNode} from 'react-treebeard-ts';

const treeData: TreeNode = {
    name: 'root',
    toggled: true,
    children: [
        {
            name: 'parent',
            children: [
                { name: 'child1' },
                { name: 'child2' }
            ]
        },
        {
            name: 'loading parent',
            loading: true,
            children: []
        },
        {
            name: 'parent',
            children: [
                {
                    name: 'nested parent',
                    children: [
                        { name: 'nested child 1' },
                        { name: 'nested child 2' }
                    ]
                }
            ]
        }
    ]
};

const TasksTree = () => {
    const [data, setData] = useState(treeData);
    const [cursor, setCursor] = useState<TreeNode | null>(null);
    
    const onToggle: ((node: TreeNode, toggled: boolean) => void) = (node, toggled) => {
        if (cursor) {
            cursor.active = false;
        }
        node.active = true;
        if (node.children) {
            node.toggled = toggled;
        }
        setCursor(node);
        setData(Object.assign({}, data))
    }
    
    return (
       <Treebeard data={data} onToggle={onToggle} />
    )
}

export default TasksTree;
