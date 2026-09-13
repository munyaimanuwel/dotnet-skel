#!/usr/bin/env bash
# Create a Clean Architecture .NET skeleton from this template.
# Usage: ./bin/new.sh My.Project [--out DIR] [--github] [--private]
set -euo pipefail

ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
TEMPLATE="$ROOT/template"

usage() {
  echo "Usage: $0 <ProjectName> [--out DIR] [--github] [--private]"
  echo "  ProjectName   e.g. Acme.Widget or MyApp (letters, digits, ., _, -)"
  echo "  --out DIR     output parent (default: .)"
  echo "  --github      create GitHub repo munyaimanuwel/<slug> and push"
  echo "  --private     with --github, make the repo private"
  exit 1
}

[[ $# -lt 1 ]] && usage
NAME="$1"
shift

OUT_PARENT="."
DO_GITHUB=0
PRIVATE=0
while [[ $# -gt 0 ]]; do
  case "$1" in
    --out) OUT_PARENT="$2"; shift 2 ;;
    --github) DO_GITHUB=1; shift ;;
    --private) PRIVATE=1; shift ;;
    -h|--help) usage ;;
    *) echo "Unknown arg: $1"; usage ;;
  esac
done

if [[ ! "$NAME" =~ ^[A-Za-z_][A-Za-z0-9._-]*$ ]]; then
  echo "Invalid project name: $NAME"
  exit 1
fi

# Folder / repo slug: lower, dots→hyphens
SLUG="$(echo "$NAME" | tr '[:upper:]' '[:lower:]' | tr '.' '-' | tr '_' '-')"
# Solution/project file stem: keep dots for namespaces
STEM="$NAME"
# Safe C# root namespace (replace - with _)
NAMESPACE="$(echo "$NAME" | tr '-' '_')"

DEST="$OUT_PARENT/$SLUG"
if [[ -e "$DEST" ]]; then
  echo "Refusing: $DEST already exists"
  exit 1
fi

mkdir -p "$DEST"
# Copy template tree; rename __NAME__ path segments
while IFS= read -r -d '' src; do
  rel="${src#"$TEMPLATE"/}"
  dest_rel="${rel//__NAME__/$STEM}"
  dest="$DEST/$dest_rel"
  mkdir -p "$(dirname "$dest")"
  if [[ -f "$src" ]]; then
    sed -e "s/__NAME__/$STEM/g" \
        -e "s/__NAMESPACE__/$NAMESPACE/g" \
        -e "s/__SLUG__/$SLUG/g" \
        "$src" > "$dest"
  fi
done < <(find "$TEMPLATE" -type f -print0)

chmod +x "$DEST" 2>/dev/null || true

echo "Created $DEST"
echo "  cd $DEST && dotnet restore && dotnet test"

if [[ "$DO_GITHUB" -eq 1 ]]; then
  if ! command -v gh >/dev/null 2>&1; then
    echo "gh not found; skip --github (files are ready locally)"
    exit 0
  fi
  VIS="--public"
  [[ "$PRIVATE" -eq 1 ]] && VIS="--private"
  (
    cd "$DEST"
    git init -b main
    git add .
    git commit -m "chore: initial Clean Architecture .NET skeleton for $STEM"
    gh repo create "munyaimanuwel/$SLUG" $VIS --source=. --remote=origin --push
  )
  echo "GitHub: https://github.com/munyaimanuwel/$SLUG"
fi
